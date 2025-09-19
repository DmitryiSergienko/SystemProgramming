// ### Шаг 3: Реализация AccountManager
// Теперь создадим класс `AccountManager`, который будет использовать различные механизмы синхронизации для работы с файлами и счетами клиентов.
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

public class AccountManager
{
    private readonly string _filePath;
    private readonly object _lockObject = new object(); // Для lock и Monitor
    private readonly Mutex _mutex = new Mutex(); // Для Mutex
    private readonly Semaphore _semaphore = new Semaphore(1, 1); // Для Semaphore

    public AccountManager(string filePath)
    {
        _filePath = filePath;
    }

    public void UpdateAccount(string clientName, decimal amount)
    {
        // Пример использования lock
        lock (_lockObject)
        {
            UpdateAccountInternal(clientName, amount);
        }

        // Пример использования Monitor
        Monitor.Enter(_lockObject);
        try
        {
            UpdateAccountInternal(clientName, amount);
        }
        finally
        {
            Monitor.Exit(_lockObject);
        }

        // Пример использования Mutex
        _mutex.WaitOne();
        try
        {
            UpdateAccountInternal(clientName, amount);
        }
        finally
        {
            _mutex.ReleaseMutex();
        }

        // Пример использования Semaphore
        _semaphore.WaitOne();
        try
        {
            UpdateAccountInternal(clientName, amount);
        }
        finally
        {
            _semaphore.Release();
        }

        // Пример использования WaitHandle (для ожидания)
        using (var waitHandle = new EventWaitHandle(false, EventResetMode.ManualReset))
        {
            // Здесь можно сделать что-то, что требует ожидания
            waitHandle.Set(); // Сигнализировать о завершении
        }
    }

    private void UpdateAccountInternal(string clientName, decimal amount)
    {
        var accounts = LoadAccounts();

        if (accounts.ContainsKey(clientName))
        {
            accounts[clientName].Balance += amount;
        }
        else
        {
            accounts[clientName] = new ClientAccount { Name = clientName, Balance = amount };
        }

        SaveAccounts(accounts);
    }

    private Dictionary<string, ClientAccount> LoadAccounts()
    {
        //Для Thread
        //if (!File.Exists(_filePath))
        //{
        //    // Создать файл с начальными данными
        //    var initialAccounts = new Dictionary<string, ClientAccount>
        //    {
        //        { "Alice", new ClientAccount { Name = "Alice", Balance = 100.00m } },
        //        { "Bob", new ClientAccount { Name = "Bob", Balance = 50.00m } }
        //    };

        //    SaveAccounts(initialAccounts); // Сохранить начальные данные в файл
        //    return initialAccounts;
        //}

        //var json = File.ReadAllText(_filePath);
        //return JsonConvert.DeserializeObject<Dictionary<string, ClientAccount>>(json);

        //Для Task
        if (!File.Exists(_filePath))
        {
            var initialAccounts = new Dictionary<string, ClientAccount>
        {
            { "Alice", new ClientAccount { Name = "Alice", Balance = 100.00m } },
            { "Bob", new ClientAccount { Name = "Bob", Balance = 50.00m } }
        };
            SaveAccounts(initialAccounts);
            return initialAccounts;
        }

        for (int attempt = 0; attempt < 5; attempt++)
        {
            try
            {
                var json = File.ReadAllText(_filePath);
                return JsonConvert.DeserializeObject<Dictionary<string, ClientAccount>>(json) ??
                       new Dictionary<string, ClientAccount>();
            }
            catch (IOException)
            {
                if (attempt == 4) throw;
                System.Threading.Thread.Sleep(20);
            }
        }

        return new Dictionary<string, ClientAccount>(); // fallback (не должно сюда дойти)
    }

    private void SaveAccounts(Dictionary<string, ClientAccount> accounts)
    {
        //Для Thread
        //var json = JsonConvert.SerializeObject(accounts, Formatting.Indented);
        //File.WriteAllText(_filePath, json);

        //Для Task
        var json = JsonConvert.SerializeObject(accounts, Formatting.Indented);

        for (int attempt = 0; attempt < 5; attempt++) // Пробуем до 5 раз
        {
            try
            {
                File.WriteAllText(_filePath, json);
                return; // Успех — выходим
            }
            catch (IOException)
            {
                if (attempt == 4) // Последняя попытка не удалась — бросаем исключение
                    throw;

                System.Threading.Thread.Sleep(20); // Ждём 20 мс и пробуем снова
            }
        }
    }
}