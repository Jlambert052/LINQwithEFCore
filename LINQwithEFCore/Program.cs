using ExtensionMethodTutorial;
using LINQwithEFCore;

"PurchaseRequestSystem".CWL();

var db = new PurchaseRequestSystemContext();

var users = db.Users.Where(u => u.Firstname.StartsWith("System")).ToList();

foreach(var user in users) {
    $"{user.Firstname} {user.Lastname}".CWL();
}

/*
List<FootballTeam> teams = new() {
    new FootballTeam { Name = "Bengals", State = "Ohio" },
    new FootballTeam { Name = "Browns", State = "Ohio" },
    new FootballTeam { Name = "Steelers", State = "Pennsylvania" },
    new FootballTeam { Name = "Ravens", State = "Maryland" },
};

var filteredTeamsInOhio = teams.Where(team => team.State == "Ohio").OrderByDescending(team => team.Name);

foreach(var team in filteredTeamsInOhio) {
    team.Name.CWL();
}
*/
/*
List<string> names = new();
names.AddRange(new string[] { "Josh", "Billy", "James", "Karl", "Caleb", "Ian", "Jack", "Sam" });
//var sortedNames = names.Where(n => n.Length % 2 == 1).OrderBy(n => n);
var sortedNames = from n in names
                  where n.Length % 2 == 1
                  orderby n
                  select n;
for (int i = 0; i < 3; i++) {
    switch (i) {
        case 0: names.Add("Abe"); break;
        case 1: names.Add("Betty"); break;
        case 2: names.Add("Chris"); break;
    }
    System.Threading.Thread.Sleep(1000);
    foreach (var name in sortedNames) {
        name.CW();
    }
    string.Empty.CWL();
}


// string[] names = { "Josh", "Billy", "James", "Karl", "Caleb", "Ian", "Jack", "Sam" };
//var sortedNames = names.Where(n => n.Length % 2 == 1).OrderBy(n => n);
*/
/*
var sortedNames = from n in names
                  where n.Length % 2 == 1
                  orderby n
                  select n;

for(int i = 0; i < 5; i++)
foreach(var name in sortedNames) {
    name.CW();
}
*/
//x^2 + 3x - 2 for fn(5)
/*
int i = 0;

5.Mult(5).Add(3.Mult(5)).Sub(2).CW();


string title = "LinqWithEFCore";
*/
/*
title.CW();

title.AppendString("Appended to string").Write();
*/
