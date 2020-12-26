# VSCHT_UPA_Generator

# Nastavení
Rozlišení: nastavte rozlišení, 1920\*1080 je standartní rozlišení

# Pravidla
Na každý řádek se dá dát jen jedna instrukce. Řádky nesmí obsahovat mezery.

# Proměnné
a, b, c, x, y
x, y jsou speciální, určují pozici pixelu.
Přiřazení probíhá následovně:
a=(funkce, nebo proměnná), například: a=b, nebo a=sin(x)

Lze taky přistupovat k barvám (stupním šedi) ostatních pixelů pomocí hranatých závorek:
a=\[-1,-4]
přiřadí do hodnoty a hodnotu pixelu, který se nachází o 1 px vlevo a 4 px nahoru.

Upozornění!
Pozitivní hodnoty v hranatých závorkách nemají úplně smysl, počítalo by se pak s přednastavenou barvou. To samé platí o \[0,0].

Na konci instrukcí každého pixelu se automaticky nastaví pixel jako stupeň šedi hodnoty proměnné a, tj. například:
...
a=sin(x)
(konec) => stupeň šedi se nastaví jako sinus pozice x pixelu.
