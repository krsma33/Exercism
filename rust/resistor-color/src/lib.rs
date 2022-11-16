use std::fmt;
use enum_iterator::*;
use int_enum::IntEnum;

#[repr(u32)]
#[derive(Debug, PartialEq, Eq, IntEnum, Copy, Clone, Sequence)]
pub enum ResistorColor {
    Black = 0,
    Blue = 6,
    Brown = 1,
    Green = 5,
    Grey = 8,
    Orange = 3,
    Red = 2,
    Violet = 7,
    White = 9,
    Yellow = 4,
}

impl fmt::Display for ResistorColor {
    fn fmt(&self, f: &mut fmt::Formatter<'_>) -> fmt::Result {
        write!(f, "{:?}", self)
    }
}

pub fn color_to_value(_color: ResistorColor) -> u32 {
    IntEnum::int_value(_color)
}

pub fn value_to_color_string(value: u32) -> String {
    let color = match ResistorColor::from_int(value) {
        Ok(c) => c.to_string(),
        Err(_) => String::from("value out of range"),
    };
    color
}

pub fn colors() -> Vec<ResistorColor> {
    let mut a = all::<ResistorColor>()
        .collect::<Vec<_>>();

    a.sort_by(|a , b| 
        { 
            let x = color_to_value(*a); 
            let y = color_to_value(*b);
            x.cmp(&y) 
        });

    a
}
