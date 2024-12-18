package game;

class CharacterFactory {
    public static Character createCharacter(String type, String name) {
        return switch (type.toLowerCase()) {
            case "warrior" -> new Warrior(name, 150, 20);
            case "mage" -> new Mage(name, 100, 40);
            case "archer" -> new Archer(name, 120, 30);
            default -> throw new IllegalArgumentException("Unknown character type: " + type);
        };
    }
}
