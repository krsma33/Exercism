use std::{collections::HashMap};

pub fn can_construct_note(magazine: &[&str], note: &[&str]) -> bool {
    let magazine_words = get_word_occurances(magazine);
    let note_words = get_word_occurances(note);

    note_words.iter()
        .all(&|(k, v)| magazine_words.get(k).unwrap_or(&0) >= v )
}

fn get_word_occurances<'a>(words: &'a [&'a str]) -> HashMap<&'a str,u32> {
    words.iter()
        .fold(HashMap::new(), |mut map, &c| {
            *map.entry(c).or_insert(0_u32) += 1;
            map
        })
}
