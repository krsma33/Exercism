#[derive(Debug, PartialEq, Eq)]
pub enum Comparison {
    Equal,
    Sublist,
    Superlist,
    Unequal,
}

pub fn sublist<T: PartialEq>(_first_list: &[T], _second_list: &[T]) -> Comparison {
    match (_first_list, _second_list) {
        ([], []) => Comparison::Equal,
        ([], _) => Comparison::Sublist,
        (_, []) => Comparison::Superlist,
        (a, b) if a.len() == b.len() && is_sublist(&a, &b) => Comparison::Equal,
        (a, b) if is_sublist(&a, &b) => Comparison::Sublist,
        (a, b) if is_sublist(&b, &a) => Comparison::Superlist,
        (_, _) => Comparison::Unequal
    }
}

fn is_sublist<T: PartialEq>(a: &[T], b: &[T]) -> bool {
    b.windows(a.len())
        .any(|w| w == a)
}
