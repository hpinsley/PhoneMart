function TestController($scope) {

    $scope.name = "Howard";
    $scope.phones = [
        { model: "Phone 1", price: 100.0 },
        { model: "Phone 2", price: 200.0}
    ];

    $scope.morePhones = function () {
        var numPhones = $scope.phones.length + 1;
        $scope.phones.push({ model: "Phone " + numPhones, price: 10.00 * numPhones });
    };

    $scope.lessPhones = function () {
        $scope.deletedPhone = $scope.phones.pop();
    };

}