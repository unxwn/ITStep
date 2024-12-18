package game;

public class GameDemo {
    public static void main(String[] args) {
        Arena arena = new Arena();
        Player player1 = new Player("Player1");
        Player player2 = new Player("Player2");

        arena.registerObserver(player1);
        arena.registerObserver(player2);
        arena.registerObserver(arena);

        Character warrior = CharacterFactory.createCharacter("warrior", "Warrior1");
        Character mage = CharacterFactory.createCharacter("mage", "Mage1");
        Character archer = CharacterFactory.createCharacter("archer", "Archer1");

        arena.addCharacter(warrior);
        arena.addCharacter(mage);
        arena.addCharacter(archer);

        arena.moveCharacter(warrior, 10, 10);
        arena.characterAttack(warrior);
        arena.moveCharacter(mage, 20, 20);
        arena.characterAttack(mage);
        arena.moveCharacter(archer, 30, 30);
        arena.characterAttack(archer);
    }
}
