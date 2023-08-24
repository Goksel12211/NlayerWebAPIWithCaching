### Integerların , Booleanların default değerleri olduğu için nullableden etkilenmez fakat Stringler ve Objeler null alabilir uyarısı verir. 
### Stringlerin  nullable olacağını kabul etmek için "?" konulabilir. -> Kirli Yol
#### ex: public string Name {get; set;} yerine
#### public string? Name {get; set;} 

## Nullable check özelliğini kapatmak için  -> Temiz Yol
### N.Layer sağ click > Properties > Build > Nullable > Disable

# Unit Of Work
## Veritabanına yapılacak işlemleri toplu bir şekilde , tek bir transaction ile yapmaya yarar. 
## Örneğin 2 entity save olacak . Biri başarılı biri başarısız . Böyle bir durumda veritabanında dengesizlik oluşur. Unit Of Work sadece 2 si başarılıysa veritabanınna işlemi yapar. Başarısızsa işlemi geri alır.
