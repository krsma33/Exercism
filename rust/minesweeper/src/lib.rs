pub fn annotate(minefield: &[&str]) -> Vec<String> {
    if minefield.len() == 0 {
        return vec![];
    }

    let table = generate_table(minefield);
    let result = populate_table(&table);
    
    result
}

type Row = Vec<Column>;
type Table = Vec<Row>;

#[derive(Clone)]
enum Column {
    Mine,
    Free { x: usize, y: usize },
    Border,
}

impl Column {
    fn check_surroundings(self: &Self, map: &Table) -> u8 {
        match self {
            Column::Mine => b'*',
            Column::Free { x, y } => {
                let mut n = b'0';

                if let Column::Mine = &map[x - 1][y - 1] {
                    n += 1;
                }

                if let Column::Mine = &map[x - 1][*y] {
                    n += 1;
                }

                if let Column::Mine = &map[x - 1][y + 1] {
                    n += 1;
                }

                if let Column::Mine = &map[*x][y - 1] {
                    n += 1;
                }

                if let Column::Mine = &map[*x][y + 1] {
                    n += 1;
                }

                if let Column::Mine = &map[x + 1][y - 1] {
                    n += 1;
                }

                if let Column::Mine = &map[x + 1][*y] {
                    n += 1;
                }

                if let Column::Mine = &map[x + 1][y + 1] {
                    n += 1;
                }

                if n == b'0' {
                    b' '
                } else {
                    n
                }
            }
            Column::Border => b'+',
        }
    }
}

fn generate_table(minefield: &[&str]) -> Table {
    let mut table =
        vec![vec![Column::Border; minefield[0].as_bytes().len() + 2]; minefield.len() + 2];

    minefield.iter().enumerate().for_each(|(i, &s)| {
        s.as_bytes().iter().enumerate().for_each(|(j, b)| {
            if b.is_ascii_whitespace() {
                table[i + 1][j + 1] = Column::Free { x: i + 1, y: j + 1 };
            } else {
                table[i + 1][j + 1] = Column::Mine;
            }
        })
    });

    table
}

fn populate_table(table: &Table) -> Vec<String> {
    table
        .iter()
        .skip(1)
        .take(table.capacity() - 2)
        .map(|r| {
            String::from_utf8(
                r.iter()
                    .skip(1)
                    .take(r.capacity() - 2)
                    .map(|c| c.check_surroundings(&table))
                    .collect::<Vec<u8>>(),
            )
            .unwrap()
        })
        .collect()
}
