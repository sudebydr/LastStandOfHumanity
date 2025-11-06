# LastStandOfHumanity

Unity ile geliştirilmiş bir oyun projesi.

## İçerik

* `Assets/Scripts/` : oyun kodları ve scriptler
* `ProjectSettings/` : proje ayarları
* `Packages/` : kullanılan Unity paketleri

> Not: Bu repo **script-only minimal proje** içerir. Oyunun full asset’leri dahil değildir.

## Projeyi çalıştırmak için

1. Unity Hub ile uygun Unity sürümünü yükleyin (örn. 2022.3.62f2).
2. Bu repo’yu bilgisayarınıza klonlayın:

   ```bash
   git clone https://github.com/sudebydr/LastStandOfHumanity.git
   ```
3. Unity Hub’dan `Open` ile proje klasörünü açın.
4. Script-only proje olduğu için bazı sahneler veya prefab’lar eksik görünebilir.

## Full Asset’leri Kullanmak

1. Full asset’ler bu bulut linkinden indirilebilir: [Full Assets İndir](https://drive.google.com/uc?export=download&id=1EZrK_GCVZVbXfv9_3QesOtaTgZbMlCrp)

2. İndirilen dosyayı açın ve **tüm içeriğini proje klasöründeki `Assets/` klasörünün içine kopyalayın**.

   * Böylece scriptler ve asset’ler birlikte olacak.
3. Son hiyerarşi şöyle görünecek:

```
LastStandOfHumanity/
├─ Assets/
│  ├─ Scripts/      ← zaten vardı
│  ├─ Scripts.meta/ ← zaten vardı
│  ├─ Effects/      ← bulut linkinden geldi
│  ├─ Effects.meta/
│  ├─ EnemyRobot/
│  ├─ EnemyRobot.meta/
│  ├─ Health Kit/
│  ├─ Health Kit.meta/
│  ├─ image/
│  ├─ image.meta/
│  └─ …            ← diğer asset klasörleri ve .meta dosyaları
├─ ProjectSettings/
└─ Packages/
```

## Notlar

* Full oyun deneyimi için asset’leri eklemek gereklidir.
* README’deki bulut linki üzerinden indirilen dosyalar **Assets klasörünün içine** konulmalıdır.
