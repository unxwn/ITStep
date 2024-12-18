package game;

import java.util.ArrayList;
import java.util.List;

class Arena implements CharacterObserver {
    private List<Character> characters = new ArrayList<>();
    private List<CharacterObserver> observers = new ArrayList<>();

    public void addCharacter(Character character) {
        characters.add(character);
        notifyObservers(character);
    }

    public void registerObserver(CharacterObserver observer) {
        observers.add(observer);
    }

    private void notifyObservers(Character character) {
        for (CharacterObserver observer : observers) {
            observer.update(character);
        }
    }

    public void moveCharacter(Character character, int x, int y) {
        character.move(x, y);
        System.out.println(character.getName() + " moved to position x=" + x + " y=" + y);
    }

    public void characterAttack(Character character) {
        character.attack();
    }

    @Override
    public void update(Character character) {
        System.out.println("game.Arena: New character added - " + character.getName());
    }
}
