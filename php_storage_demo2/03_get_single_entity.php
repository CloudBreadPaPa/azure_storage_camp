<?php
require_once 'vendor\autoload.php';
//ini_set('display_errors', 1);
//error_reporting(~0);

use WindowsAzure\Common\ServicesBuilder;
use WindowsAzure\Common\ServiceException;

// Storage의 connection string 제공
$connectionString = "DefaultEndpointsProtocol=http;AccountName=<저장소이름>;AccountKey=<저장소키>";

// Azure의 table storage를 위한 REST proxy 생성
$tableRestProxy = ServicesBuilder::getInstance()->createTableService($connectionString);

/////////////////////////////////////////////////////////////////
// 03 SELECT 1건 조회 처리
/////////////////////////////////////////////////////////////////
try {
    // 조회
    $result = $tableRestProxy->getEntity("phptable", "KCD", "{331295A8-27B5-3AF1-C91B-D9F76B9715EF}");      //guid값
}
catch(ServiceException $e){
    $code = $e->getCode();
    $error_message = $e->getMessage();
    echo $code.": ".$error_message."<br />";
}

//결과 조회
$entity = $result->getEntity();
echo $entity->getPartitionKey().":".$entity->getRowKey();

?>