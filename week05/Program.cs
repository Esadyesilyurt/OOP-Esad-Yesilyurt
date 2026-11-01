// PART A cevaplar (calistirmadan once yazdim)
// A1: 5
// A2: Hurt
// A3: 4
// A4: 14

// ===== B1 =====
{
    int baseDamage = 40;
    int armor = 15;
    int level = 4;

    int dmg = baseDamage - armor;
    if (level >= 5)
    {
        dmg = dmg + 10; // level bonusu
    }
    if (dmg < 1)
    {
        dmg = 1;
    }

    if (dmg >= 30)
        Console.WriteLine("Damage: " + dmg + " (Strong hit)");
    else if (dmg >= 10)
        Console.WriteLine("Damage: " + dmg + " (Normal hit)");
    else
        Console.WriteLine("Damage: " + dmg + " (Weak hit)");

    // level 6 ile denedim 35 strong hit cikti
    // armor 50 ile denedim 1 weak hit cikti
}

// ===== B2 =====
{
    int gold = 120;
    int choice = 2;
    string esya = "";
    int fiyat = 0;

    switch (choice)
    {
        case 1:
            esya = "Sword";
            fiyat = 100;
            break;
        case 2:
            esya = "Bow";
            fiyat = 80;
            break;
        case 3:
            esya = "Potion";
            fiyat = 25;
            break;
        default:
            Console.WriteLine("Invalid choice");
            break;
    }

    // gecerli secim yapildiysa satin alma kontrolu
    if (fiyat > 0)
    {
        if (gold >= fiyat)
        {
            gold = gold - fiyat;
            Console.WriteLine("You bought a " + esya + "! Gold left: " + gold);
        }
        else
        {
            Console.WriteLine("Not enough gold, you need " + (fiyat - gold) + " more");
        }
    }
}

// ===== B3 =====
{
    for (int i = 1; i <= 30; i++)
    {
        // once 15e bolunmeyi kontrol etmek lazim yoksa slime yaziyor
        if (i % 15 == 0)
            Console.WriteLine("Wave " + i + ": BOSS");
        else if (i % 3 == 0)
            Console.WriteLine("Wave " + i + ": Slime");
        else if (i % 5 == 0)
            Console.WriteLine("Wave " + i + ": Bat");
        else
            Console.WriteLine("Wave " + i + ": empty");
    }
}

// ===== B4 =====
{
    int level = 1;
    int xp = 0;
    int fights = 0;

    while (level < 5)
    {
        fights++;
        xp += 35;
        if (xp >= 100)
        {
            xp -= 100;
            level++;
            Console.WriteLine("LEVEL UP! Now level " + level);
        }
    }
    Console.WriteLine("Reached level 5 after " + fights + " fights (xp left: " + xp + ")");
}

// ===== B5 =====
{
    int Clamp(int value, int min, int max)
    {
        if (value < min)
            return min;
        if (value > max)
            return max;
        return value;
    }

    Console.WriteLine(Clamp(150, 0, 100));
    Console.WriteLine(Clamp(-20, 0, 100));
    Console.WriteLine(Clamp(55, 0, 100));

    int hp = 80;
    hp = Clamp(hp + 50, 0, 100); // potion +50 ama 100u gecmesin
    Console.WriteLine("HP after potion: " + hp);
}

// ===== B6 =====
{
    string GetRank(int score)
    {
        if (score >= 1000) return "Gold";
        else if (score >= 500) return "Silver";
        else if (score >= 1) return "Bronze";
        else return "No medal";
    }

    for (int s = 0; s <= 1250; s += 250)
    {
        Console.WriteLine("Score " + s + ": " + GetRank(s));
    }
}

// ===== B7 =====
{
    int Attack(int hp, int damage)
    {
        hp = hp - damage;
        if (hp < 0) hp = 0;
        return hp;
    }

    bool IsAlive(int hp)
    {
        return hp > 0;
    }

    int oyuncuHp = 150;
    int bossHp = 120;
    int tur = 0;

    while (IsAlive(oyuncuHp) && IsAlive(bossHp))
    {
        tur++;

        // once oyuncu vuruyor
        bossHp = Attack(bossHp, 25);
        if (!IsAlive(bossHp))
        {
            Console.WriteLine("Turn " + tur + " | Boss: " + bossHp);
            break; // boss oldu geri vuramaz
        }

        // her 3. turda boss iki kat vuruyor
        if (tur % 3 == 0)
            oyuncuHp = Attack(oyuncuHp, 50);
        else
            oyuncuHp = Attack(oyuncuHp, 25);

        Console.WriteLine("Turn " + tur + " | Boss: " + bossHp + " | Player: " + oyuncuHp);
    }

    if (IsAlive(oyuncuHp))
        Console.WriteLine("You win in " + tur + " turns! HP left: " + oyuncuHp);
    else
        Console.WriteLine("You lose in " + tur + " turns!");
}

// ===== B8 =====
{
    string Hint(int guess, int secret)
    {
        if (guess < secret) return "Too low";
        if (guess > secret) return "Too high";
        return "Correct!";
    }

    int secret = 42;
    //int secret = new Random().Next(1, 101); // bonus kismi

    int hak = 5;
    int deneme = 0;
    bool bildi = false;

    while (hak > 0)
    {
        Console.Write("Guess (" + hak + " tries left): ");
        int tahmin = int.Parse(Console.ReadLine());
        deneme++;
        hak--;

        Console.WriteLine(Hint(tahmin, secret));

        if (tahmin == secret)
        {
            bildi = true;
            break;
        }
    }

    if (bildi)
        Console.WriteLine("You found it in " + deneme + " tries!");
    else
        Console.WriteLine("You lose! Number was " + secret);
}
