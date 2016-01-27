// 패키지 import 수행
var azure = require('azure-storage');

var tableService = azure.createTableService('<저장소이름>', '<저장소키>');

// 테이블 조회를 수행하기 위한 쿼리 생성
var query = new azure.TableQuery()
  .top(5)
  .where('PartitionKey eq ?', 'KCD');	// 파티션키 조건

// 쿼리 수행
tableService.queryEntities('nodetable',query, null, function(error, result, response) {
  if(!error) {
    console.log(response);
	console.log(result);
  } else {
	  console.log(error);
  }
});
