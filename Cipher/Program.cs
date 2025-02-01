using System.Text;

namespace Cipher;

class Program
{
    static void Main()
    {
        Menu();
    } // Skończony - brak błędów

    static void Menu()
    {
        Console.WriteLine("1) Szyfrowanie");
        Console.WriteLine("2) Deszyfrowanie");
        Console.WriteLine("3) Wyjście");
        Console.Write("Podaj opcję: ");
        int choice;
        try
        {
            choice  = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception)
        {
            choice = 0;
        }
        
        if (choice == 1)
        {
            Console.WriteLine("1) Szyfr Cezar");
            Console.WriteLine("2) Szyfr Vigenere'a");
            Console.WriteLine("3) Powrót");
            Console.Write("Podaj opcję: ");
            int choiceEncrypt;
            
            try
            {
                choiceEncrypt  = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                choiceEncrypt = 0;
            }
            
            if (choiceEncrypt == 1)
            {
                EncryptCezar();
            }
            else if (choiceEncrypt == 2)
            {
                EncryptVigenerea();
            }
            else if (choiceEncrypt == 3)
            {
                Menu();
            }
            else
            {
                Console.WriteLine("Wprowadzono nieprawidłową opcję!");
                Menu();
            }
        }
        else if (choice == 2)
        {
            Console.WriteLine("1) Szyfr Cezar");
            Console.WriteLine("2) Szyfr Vigenere'a");
            Console.WriteLine("3) Powrót");
            Console.Write("Podaj opcję: ");
            int choiceDecrypt;
            
            try
            {
                choiceDecrypt  = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                choiceDecrypt = 0;
            }
            
            if (choiceDecrypt == 1)
            {
                DecryptCezar();
            }
            else if (choiceDecrypt == 2)
            {
                DecryptVigenerea();
            }
            else if (choiceDecrypt == 3)
            {
                Menu();
            }
            else
            {
                Console.WriteLine("Wprowadzono nieprawidłową opcję!");
                Menu();
            }
        }
        else if (choice == 3)
        {
            Console.WriteLine("Do widzenia!");
            Console.WriteLine("Dziękujemy za skorzystanie z programu!");
        }
        else
        {
            Console.WriteLine("Wprowadzono nieprawidłową opcję!");
            Menu();
        }
    } // Skończony - brak błędów

    static int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    } // Skończony - brak błędów
    
    static void EncryptCezar() 
    {
        string input = "";
        bool isCorrect = true;
        
        while (input == "")
        {
            Console.Write("Podaj zdanie do zaszyfrowania (a - z): ");
            input = Console.ReadLine() ?? "";
        }
        
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] < 97 || input[i] > 122)
            {
                Console.WriteLine("Wprowadzono nieprawidłowe znaki!");
                isCorrect = false;
                break;
            }
        }

        if (isCorrect)
        {
            int key = RandomNumber(3, 6);
            Console.WriteLine("Wylosowany klucz: " + key);
            StringBuilder encryptedWord = new StringBuilder("");

            for (int i = 0; i < input.Length; i++)
            {
                char sign = input[i];
    
                for (int j = 0; j < key; j++)
                {
                    if (sign >= 122)
                    {
                        sign = (char)(96 + 1);
                    }
                    else
                    {
                        sign = (char)(sign + 1);
                    }
                }
    
                encryptedWord.Append(sign);
            }

            Console.WriteLine(encryptedWord);
        }
        
        Menu();
    } // Skończony - brak błędów

    static void DecryptCezar() 
    {
        string input = "";
        bool isCorrect = true;
        
        while (input == "")
        {
            Console.Write("Podaj zdanie do zaszyfrowania (a - z): ");
            input = Console.ReadLine() ?? "";
        }
        
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] < 97 || input[i] > 122)
            {
                Console.WriteLine("Wprowadzono nieprawidłowe znaki!");
                isCorrect = false;
                break;
            }
        }

        if (isCorrect)
        {
            int key;
        
            do
            {
                Console.Write("Podaj klucz: ");
            } while (!int.TryParse(Console.ReadLine(), out key));
            StringBuilder encryptedWord = new StringBuilder("");

            for (int i = 0; i < input.Length; i++)
            {
                char sign = input[i];
            
                for (int j = 0; j < key; j++)
                {
                    if (sign <= 97)
                    {
                        sign = (char)(123 - 1);
                    }
                    else
                    {
                        sign = (char)(sign - 1);
                    }
                }
            
                encryptedWord.Append(sign);
            }

            Console.WriteLine(encryptedWord);
        }

        Menu();
    } // Skończony - brak błędów

    static void EncryptVigenerea()
    {
        char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        string input = "";
        string key = "";
        bool isCorrect = true;
        
        while (input == "")
        {
            Console.Write("Podaj zdanie do zaszyfrowania (a - z): ");
            input = Console.ReadLine() ?? "";
        }
        
        for (int i = 0; i < input.Length; i++)
        {
            if (!isCorrect)
            {
                break;
            }
            
            for (int j = 0; j < alphabet.Length; j++)
            {
                if (input[i] == alphabet[j])
                {
                    isCorrect = true;
                    break;
                }
                else 
                {
                    isCorrect = false;
                }
            }
        }

        if (isCorrect)
        {
            while (key == "")
            {
                Console.Write("Podaj klucz: ");
                key = Console.ReadLine() ?? "";
            }
            
            for (int i = 0; i < key.Length; i++)
            {
                if (!isCorrect)
                {
                    break;
                }
            
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (key[i] == alphabet[j])
                    {
                        isCorrect = true;
                        break;
                    }
                    else 
                    {
                        isCorrect = false;
                    }
                }
            }
        }

        if (isCorrect)
        {
            StringBuilder encryptedWord = new StringBuilder("");
            int currentIndex = 0;
        
            for (int i = 0; i < input.Length; i++)
            {
                char sign = input[i];
                int addKey = 0;
                int signKey = 0;

                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (key[currentIndex] == alphabet[j])
                    {
                        addKey = j + 1;
                    }
                }
            
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (sign == alphabet[j])
                    {
                        signKey = j;
                    }
                }
            
                for (int j = 0; j < alphabet.Length; j++)
                {
                    sign = (signKey + addKey) % 26 == j ? alphabet[j] : sign;

                }

                currentIndex++;
            
                if (currentIndex > key.Length - 1)
                {
                    currentIndex = 0;
                }
            
                encryptedWord.Append(sign);
            }

            Console.WriteLine(encryptedWord);
        }
        else
        {
            Console.WriteLine("Wprowadzono nieprawidłowe znaki!");
        }
        
        Menu();
    } // Skończony - brak błędów

    static void DecryptVigenerea()
    {
                
        char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        bool isCorrect = true;
        string input = "";
        string key = "";
        
        while (input == "")
        {
            Console.Write("Podaj zdanie do zaszyfrowania (a - z): ");
            input = Console.ReadLine() ?? "";
        }
        
        for (int i = 0; i < input.Length; i++)
        {
            if (!isCorrect)
            {
                break;
            }
            
            for (int j = 0; j < alphabet.Length; j++)
            {
                if (input[i] == alphabet[j])
                {
                    isCorrect = true;
                    break;
                }
                else 
                {
                    isCorrect = false;
                }
            }
        }

        if (isCorrect)
        {
            while (key == "")
            {
                Console.Write("Podaj klucz: ");
                key = Console.ReadLine() ?? "";
            }
            
            for (int i = 0; i < key.Length; i++)
            {
                if (!isCorrect)
                {
                    break;
                }
            
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (key[i] == alphabet[j])
                    {
                        isCorrect = true;
                        break;
                    }
                    else 
                    {
                        isCorrect = false;
                    }
                }
            }
        }
        
        StringBuilder encryptedWord = new StringBuilder("");

        if (isCorrect)
        {
            int currentIndex = 0;
            int addKey = 0;
            int signKey = 0;
        
            for (int i = 0; i < input.Length; i++)
            {
                char sign = input[i];

                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (key[currentIndex] == alphabet[j])
                    {
                        addKey = j + 1;
                    }
                }
            
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (sign == alphabet[j])
                    {
                        signKey = j;
                    }
                }
            
                for (int j = 0; j < alphabet.Length; j++)
                {
                    sign = signKey - addKey < 0 ? alphabet[26 + (signKey - addKey)] : alphabet[signKey - addKey];
                }

                currentIndex++;
            
                if (currentIndex > key.Length - 1)
                {
                    currentIndex = 0;
                }
            
                encryptedWord.Append(sign);
            }
            Console.WriteLine(encryptedWord);
        }
        else
        {
            Console.WriteLine("Wprowadzono nieprawidłowe znaki!");
        }
        
        Menu();
    } // Skończony - brak błędów
}