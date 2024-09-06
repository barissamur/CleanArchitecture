namespace CleanArchitecture.Application.Common.Models;

public class CustomResult
{
    // Constructor, başarılı veya başarısız sonucu ve hataları kabul eder
    internal CustomResult(bool succeeded, object? data = null, IEnumerable<string>? errors = null)
    {
        Succeeded = succeeded;
        Data = data;
        Errors = errors?.ToArray() ?? Array.Empty<string>();
    }

    // İşlemin başarılı olup olmadığını gösterir
    public bool Succeeded { get; init; }

    // Dönülen veri, her türde olabilir (örneğin, başarı durumunda data set edilebilir)
    public object? Data { get; init; }

    // Hata mesajları, başarısızlık durumunda burada yer alır
    public string[] Errors { get; init; }

    // Başarılı bir sonuç döndüren fabrika metodu
    public static CustomResult Success(object? data = null)
    {
        return new CustomResult(true, data);
    }

    // Başarısız bir sonuç döndüren fabrika metodu
    public static CustomResult Failure(IEnumerable<string> errors)
    {
        return new CustomResult(false, null, errors);
    }
}
