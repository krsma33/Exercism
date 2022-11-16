const RADIX: u32 = 10;

/// Check a Luhn checksum.
pub fn is_valid(code: &str) -> bool {
    let filtered = code.chars()
        .filter(|b| !b.is_ascii_whitespace());
        
    if filtered.clone().any(|c| !c.is_ascii_digit()) {
        return false;
    }

    let length = filtered.clone().count();

    if length == 1 {
        return false;
    }

    let parity = length % 2;

    let sum = filtered
        .filter(|b| b.is_ascii_digit())
        .map(|c| c.to_digit(RADIX).unwrap())
        .enumerate()
        .fold(0u32, |acc , (i, n)|
            match (i+1, n) {
                (index, number) if index % 2 == parity => acc + number,
                (_, number) if number > 4 => acc + 2 * number - 9,
                (_, number) => acc + 2 * number
            });

    sum % 10 == 0
}
