<h2>Informacija</h2>
<p>Egzistuoja 2 enticiai - Voucher ir VoucherCode. VoucherCodes yra unikalus kiekvienam Voucher (t.y. VoucherA ir VoucherB gali tureti ta pati koda).</br></br>
Naudoju Dapper micro ORM, MSSQL(naudoju ji pirma karta, tad gal kazkas bus ne taip). MSSQL yra surisimas lenteliu Voucher ir VoucherCode.</br></br>
Galima dar parasyt unit testus Voucher ir voucher code metodams, bet kadangi optional, tai palikau sita veikla.</br></br>
Uzduotyje nurodyta kokie turi buti uzklausos parametrai, taciau nusprendziau siek tiek pakeist uzduoti, kad galima butu sukurti daug skirtingu "Akciju" ir ju "Kodu", todel uzkausos parametrai siek tiek pasikeite. Neapsisprendziau, ar kodai turi buti unikalus visiem bendrai, ar kiekvienam atskirai, tad padariau kiekvienam atskirai.</br></br>
"Komunikacija su kliento dalimi" as suvokiau kaip api endpointai. Patogumui atlikti testavimus naudojamas swagger.
</p>
<h2>Naudojimas</h2>
<ol>
<li>Padaryt VoucherDb projekto publish. Duombazes pavadinimas "Db". Jeigu neveiks, reikes pakeisti connection string in appsettings.json file.
  <li>Sukurti Voucher su api/voucher POST uzklausa (grazins sukurto voucher id)</li>
  <li>Sugeneruoti kodus su api/voucher/generate-codes POST uzklausa</li>
  <li>Panaudoti koda su api/voucher/use-code POST uzklausa</li>
</ol>
<h2>Papildoma informacija</h2>
<p>Kuriant voucher kodus reikes nurodyti simboliu skaiciu ir kodu kieki. Uzduotyje pamineta, jog 7 ar 8 simboliai(tad ivedus kita skaiciu grazins FALSE) ir nuo 1000 iki 2000 vienetu (tad ivedus maziau uz 1000 ar daugiau uz 2000 grazins FALSE)</p>

Pagarbiai.
