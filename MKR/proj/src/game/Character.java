package game;

interface Character {
    void move(int x, int y);
    void attack();
    String getName();
    int getHealth();
    int getAttackPower();
    Point getPosition();
}
