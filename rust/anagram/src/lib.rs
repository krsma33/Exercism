use std::collections::HashSet;

pub fn anagrams_for<'a>(word: &str, possible_anagrams: &[&'a str]) -> HashSet<&'a str> {
    let word_upper = word.to_uppercase();
    let word_sorted = sort_word(&word_upper);

    possible_anagrams
        .iter()
        .filter(|a| {
            let anagram_upper = a.to_uppercase();
            anagram_upper.len() == word_upper.len()
                && anagram_upper != word_upper
                && sort_word(&anagram_upper) == word_sorted
        })
        .cloned()
        .collect()
}

fn sort_word(word: &str) -> Vec<char> {
    let mut word_letters: Vec<char> = word.chars().collect();
    word_letters.sort_unstable();
    word_letters
}
