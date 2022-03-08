using Grpc.Net.Client;
using WorkLeave;
using WorkLeaveClient.Helper;

var chanel = GrpcChannel.ForAddress("http://localhost:50050");
var client = new EmployeeLeaveDaysService.EmployeeLeaveDaysServiceClient(chanel);

Employee employeeRequest = WorkLeaveModelHelper.employeeRequest;

#region EligibleForLeave
LeaveEligibility? eligibilityResponse = await client.EligibleForLeaveAsync(employeeRequest);

if (eligibilityResponse is not null)
    Console.WriteLine(eligibilityResponse);
#endregion EligibleForLeave

#region GrantLeave
LeaveFeedback? grantResponse = await client.grantLeaveAsync(employeeRequest);

if (grantResponse is not null)
    Console.WriteLine(grantResponse);
#endregion GrantLeave

Console.ReadKey();