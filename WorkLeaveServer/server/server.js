const grpc = require("grpc");
const proto = grpc.load("protos/vacaciones.proto");
const server = new grpc.Server();

server.addService(proto.work_leave.EmployeeLeaveDaysService.service, {
  eligibleForLeave(call, callback) {
    if (call.request.requested_leave_days > 0) {
      if (call.request.accrued_leave_days > call.request.requested_leave_days) {
        callback(null, { eligible: true });
      } else {
        callback(null, { eligible: false });
      }
      -1;
    } else {
      callback(new Error("Invalid requested days"));
    }
  },

  /**
Grant an employee leave days
*/
  grantLeave(call, callback) {
    let granted_leave_days = call.request.requested_leave_days;
    let accrued_leave_days =
      call.request.accrued_leave_days - granted_leave_days;
    callback(null, {
      granted: true,
      granted_leave_days,
      accrued_leave_days,
    });
  },
});
//Specify the IP and and port to start the grpc Server, no SSL in test environment
server.bind("0.0.0.0:50050", grpc.ServerCredentials.createInsecure());
//Start the server
server.start();
console.log("grpc server running on port:", "0.0.0.0:50050");
