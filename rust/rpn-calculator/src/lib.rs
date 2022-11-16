#[derive(Debug)]
pub enum CalculatorInput {
    Add,
    Subtract,
    Multiply,
    Divide,
    Value(i32),
}

pub fn evaluate(inputs: &[CalculatorInput]) -> Option<i32> {
    let mut vec = Vec::new();

    for input in inputs {

        if let CalculatorInput::Value(v) = input {
            vec.push(*v);
            continue;
        }

        let second = vec.pop()?;
        let first = vec.pop()?;

        match input {
            CalculatorInput::Add => vec.push(first + second),
            CalculatorInput::Subtract => vec.push(first - second),
            CalculatorInput::Multiply => vec.push(first * second),
            CalculatorInput::Divide => vec.push(first / second),
            CalculatorInput::Value(v) => vec.push(*v),
        };
    }

    match vec[..] {
        [single] => Some(single),
        _ => None
    }
}