'use strict';

nagApp.controller('PhoneController', function PhoneController($scope, phoneData, $location) {

    $scope.phones = phoneData.getPhones(); //this is a promise that Angular knows how to bind to
    $scope.manufacturers = phoneData.getManufacturers();
    $scope.filters = {};
    
    //When you pass the scoped object (which is a promise) back
    //into a controller method, Angular unwraps the real object for you.

    $scope.displayPhone = function (phone) {
        alert("Model: " + phone.model + "\n\n" + phone.description);
    };

    $scope.addPhone = function () {
        $location.path("/phones/add");
    };

    $scope.manufacturerSelected = function() {
        var manufacturer = $scope.selectedManufacturer;
        if (!manufacturer)
            return;
        console.log("You selected " + manufacturer);

        if (manufacturer == -1) {
            $scope.filters = {};
        } else {
            //$scope.filters = { manufacturerId: manufacturer };
            $scope.filters["manufacturer.manufacturerId"] = manufacturer;
            console.log($scope.filters);
        }
    };

});
