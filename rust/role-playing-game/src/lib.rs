pub struct Player {
    pub health: u32,
    pub mana: Option<u32>,
    pub level: u32,
}

impl Player {
    pub fn revive(&self) -> Option<Player> {
        if self.health == 0 {
            return match self.level {
                num if num < 10 => Some(Player { health: 100, mana: None, level: self.level }),
                _ => Some(Player { health: 100, mana: Some(100), level: self.level })
            }
        }
        else {
            return None;
        }
    }

    pub fn cast_spell(&mut self, mana_cost: u32) -> u32 {
        match self.mana {
            Some(mana) if mana < mana_cost => 0,
            Some(mana) => {
                self.mana = Some(mana - mana_cost);
                mana_cost * 2
            },
            None if self.health < mana_cost => {
                self.health = 0;
                0
            },
            None => {
                self.health = self.health - mana_cost;
                0
            }
        }
    }
}
