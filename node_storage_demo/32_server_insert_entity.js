// 패키지 import 수행
var azure = require('azure-storage');

// RowKey를 unique하게 생성하기 위한 uuid 생성 패키지 import
var uuid = require('node-uuid');		// 추가 https://github.com/broofa/node-uuid

var tableService = azure.createTableService('<저장소이름>', '<저장소키>');

var entGen = azure.TableUtilities.entityGenerator;

// task entity 변수 생성
var task = {
  PartitionKey: entGen.String('KCD'),
  RowKey: entGen.String(uuid.v1()),
  description: entGen.String('KCD + node가 쵝오에요~'),
  dueDate: entGen.DateTime(new Date(Date.UTC(2015, 11, 17))),
};

// insert 작업 수행
tableService.insertEntity('nodetable', task, function (error, result, response) {
    if(!error){
	  console.log(response);
    } else {
	  console.log(error);
  }
});
