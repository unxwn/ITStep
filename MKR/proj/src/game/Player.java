package game;

class Player implements CharacterObserver {
    private String name;

    public Player(String name) {
        this.name = name;
    }

    @Override
    public void update(Character character) {
        System.out.println("Player " + name + " notified: New character " + character.getName() + " appeared");
    }
}
