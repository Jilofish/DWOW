using DWOW.Models;
using DWOW.Repositories;

namespace DWOW.Services;

public class QuestService : IQuestService
{
    public List<Quest> GetQuests()
    {
        List<Quest> QuestsList = [
            new() { ImageUrl = "https://images.squarespace-cdn.com/content/v1/65296fd6785a5942a57d22e7/1697214472386-0P3BGII59ZFD5DOQG3YV/Circuit-of-Americas.png?format=2500w",
                        Code = "QST-100001",
                        Name = "Circuit of Americas",
                        Criteria = "Circuit length, 5.513 km. Number of laps, 56. Race distance, 308.405 km." },
            new() { ImageUrl = "https://images.squarespace-cdn.com/content/v1/65296fd6785a5942a57d22e7/1697214472427-ACJCXZKRTKTAN2XBM20X/Miami.png?format=2500w",
                        Code = "QST-100002",
                        Name = "Miami Circuit",
                        Criteria = "Circuit length, 5.412 km. Number of laps, 57. Race distance, 308.326 km." },
            new() { ImageUrl = "https://www.sportmonks.com/wp-content/uploads/2022/07/Jeddah-Corniche-Circuit.png",
                        Code = "QST-100003",
                        Name = "Jeddah Street Circuit",
                        Criteria = "Circuit length, 6.174 km. Number of laps, 50. Race distance, 308.450 km."}
        ];

        return QuestsList;
    }
}
