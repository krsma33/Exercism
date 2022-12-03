use std::collections::HashMap;
use std::sync::mpsc::{channel, Receiver, Sender};
use std::thread;
use std::time::Duration;

enum Job<T: Send> {
    Item(T),
    Stop,
}

pub fn frequency(input: &[&'static str], worker_count: usize) -> HashMap<char, usize> {
    let (tx, rx) = channel::<Job<char>>();

    let workers: Vec<_> = (0..worker_count)
        .map(|_| {
            let (jtx, jrx) = channel::<Job<&str>>();
            let tx = tx.clone();
            thread::spawn(move || process_job(jrx, tx));
            jtx
        })
        .collect();

    input
        .iter()
        .zip(workers.iter().cycle())
        .for_each(|(word, jtx)| jtx.send(Job::Item(word)).unwrap());

    workers.iter().for_each(|w| w.send(Job::Stop).unwrap());

    count_l(rx)
}

fn count_l(rx: Receiver<Job<char>>) -> HashMap<char, usize> {
    let mut map = HashMap::new();

    loop {
        match rx.recv_timeout(Duration::from_millis(5)) {
            Ok(Job::Item(c)) => {
                *map.entry(c.to_ascii_lowercase()).or_insert(0) += 1;
            }
            Ok(Job::Stop) => break,
            Err(_) => break,
        }
    }

    map
}

fn process_job(work_item: Receiver<Job<&str>>, result: Sender<Job<char>>) {
    loop {
        match work_item.recv() {
            Ok(Job::Item(word)) => word.chars().for_each(|c| {
                if c.is_alphabetic() {
                    result.send(Job::Item(c)).unwrap();
                }
            }),
            Ok(Job::Stop) => break,
            Err(_) => (),
        }
    }
}
