package game;

class Mage implements Character {
    private String name;
    private int health;
    private int attackPower;
    private Point position;

    public Mage(String name, int health, int attackPower) {
        this.name = name;
        this.health = health;
        this.attackPower = attackPower;
        this.position = new Point(0, 0);
    }

    public void move(int x, int y) {
        this.position = new Point(x, y);
    }

    public void attack() {
        System.out.println("game.Mage casts spell with power " + attackPower);
    }

    public String getName() { return name; }
    public int getHealth() { return health; }
    public int getAttackPower() { return attackPower; }
    public Point getPosition() { return position; }
}
