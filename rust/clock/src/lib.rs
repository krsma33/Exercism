use std::fmt::Display;

const MINUTES_PER_HOUR: i32 = 60;
const MINUTES_PER_DAY: i32 = 1440;

#[derive(PartialEq, Eq, Debug)]
pub struct Clock{ 
    hours: i32, 
    minutes: i32
}

impl Clock {
    pub fn new(hours: i32, minutes: i32) -> Self {

        let total_minutes = get_abs_minutes(hours * MINUTES_PER_HOUR + minutes);

        let min = match total_minutes {
            m if m < 0 => MINUTES_PER_DAY + m,
            m => m
        };

        let hours = min / MINUTES_PER_HOUR;
        let minutes = min % MINUTES_PER_HOUR;

        Clock { 
            hours, 
            minutes 
        }
    }

    pub fn add_minutes(&self, minutes: i32) -> Self {
        Clock::new(self.hours, self.minutes + minutes)
    }
}

impl Display for Clock {
    fn fmt(&self, f: &mut std::fmt::Formatter<'_>) -> std::fmt::Result {
        write!(f, "{:02}:{:02}", self.hours, self.minutes)
    }
}

fn get_abs_minutes(minutes: i32) -> i32 {
    let abs_minutes = minutes % MINUTES_PER_DAY;
    if abs_minutes <= MINUTES_PER_DAY {
        return abs_minutes;
    } else {
        return get_abs_minutes(abs_minutes);
    }
}
