// See https://aka.ms/new-console-template for more information
using swimmingTeam.model;

Console.WriteLine("Hello, World!");

Member m1 = new Member();
Member m2 = new Member(9, "22334455", "Peter", 2020);


Team team = new Team(44, 2, 10, "mandag");
team.EnrollMember(m1);
team.EnrollMember(m2);

try
{
    team.EnrollMember(m1);


}
catch(ArgumentOutOfRangeException aoore)
{
    Console.WriteLine(aoore.Message);
}
catch(Exception ane)
{
    Console.WriteLine(ane.Message);
}


Console.WriteLine(team);

List<Member> members = team.GetAllMembers();
foreach (Member m in members)
{
    Console.WriteLine(  m );
}