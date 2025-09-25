// ### Шаг 2: Создание модели данных
// Создайте класс для представления счета клиента:
public class ClientAccount
{
    public string? Name { get; set; }
    public decimal Balance { get; set; }
    public ClientAccount() { }
    public ClientAccount(string name, decimal balance)
    {
        Name = name;
        Balance = balance;
    }
}