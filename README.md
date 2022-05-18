#sigma6project.sln version 1.1 çalıştırılacak.
#sigma6.bak implemente edilierek veritabanı bağlantısı yapılacaktır.

#LoginPage 
-Kayıt Butonu;
  RegisterPage açılır. Kullanıcı adı şifre mail ad soyad ve hesap türü belirlenir. Girilen veriler Personal veritipinde databasemizdeki InsertPerson metodumuza parametre olarak gönderilir ve kayıt edilir.
  Kayıt ekranında şifre kontrolu yapılır ve eşleşmesi gerekmektedir.

-Giriş Butonu;
  Kullanıcı ve şifre textbox içindeki verileri Personal veritipinde databasemizdeki LoginPerson metoduna parametre olarak gönderiyoruz.
  Veriler eşleşiyor ve doğru ise giriş yapılan kullanıcının UserTypeId return edilir.
  Böylece Açılacak page belirlenir.
  -Şifremi Unuttum;
   Mail adresi ile şifre kurtarma yapılır.
  #ExaminerPage(SınavSorumlusu)
   -Soru Ekleme;
    Sorunun üst alt bilgi, resim yolu, doğru ve diğer şıkları Question veri tipinde databasemize QuestionAdd'a parametre olarak gönderilerek soru eklenir.
    (Eklenen sorular admin tarafından onaylanması gerekmektedir)
   
   #AdminPage
   -Load olduğunda database ile QuestionAdminData metodu aracılığıyla onaylanmamış sorular çekilir.
   -Onaylanmamış sorular onayla butonu ile AdminQuestionConfirmation ile T edilir ve onaylanır.
   - İstenirse soru ekleme ekranına gidilebilir.
   
   #MainPage(ÖğrenciGiriş)
   -Süresiz Quiz
   -Süreli Quiz
   -Analiz butonları bulunmaktadır.#(Sigma6 Algoritmasını aşağıda anlattım)
       Quiz başladığında UserExamResults veritabanı tablosu create edilir. UserID(sınava giren kişinin idsi),QuızId(otomatik atanır),QuizDate(Bugunun tarihi) ve quizid     return edilir.
       Quizde cevaplanan sorular return edilen quizid ile QuestionDetails tablosunda cevaplanan her sorunun doğru yanlış ve boş işaretlediği tutulur ve gerekli sorguyu     kullanarak sigma6prensibini projeye implemente ettim.
       Böylece;
       Quiz başlatıldığında ilk olarak database classımızdan Sigma6Load çalışır. Soru sıklığı otomatik 1 gün tanımlanmıştır. 1 gün önce yapılan quiz için doğru yapılan       sorular quiz öncesi load edilir. Sigma6 ile çekilen sorular cevaplandıktan sonra 10 tane rastgele quiz sorusu QuizStart ile load edilir.
    -İstenir ise UserExamResults QuizDetails innerjoin ile genel bir analiz rapor oluşturulabilir(tamamlayamadım)


