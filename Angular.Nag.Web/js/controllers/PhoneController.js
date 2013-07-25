'use strict';

nagApp.controller('PhoneController', function PhoneController($scope, phoneData, $location) {

    $scope.phones = phoneData.getPhones(); //this is a promise that Angular knows how to bind to

    //When you pass the scoped object (which is a promise) back
    //into a controller method, Angular unwraps the real object for you.

    $scope.displayPhone = function (phone) {
        alert("Model: " + phone.model + "\n\n" + phone.description);
    };

    $scope.addPhone = function () {
        $location.path("/phones/add");
    };

});
