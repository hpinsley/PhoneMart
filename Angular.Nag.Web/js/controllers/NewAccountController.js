'use strict';

nagApp.controller('NewAccountController', function NewAccountController($scope, $http, $location) {

    $scope.addAccount = function () {
        $http({
            method: "POST",
            url: "http://localhost/Angular.Nag.Services/api/accounts",
            data: {
                fullName: $scope.fullName,
                contactPhoneNumber: $scope.contactPhoneNumber,
                emailAddress: $scope.emailAddress
            }
        })
        .success(function (data) {
            alert("New account created " + data);
            $location.path("/accounts");
        })
        .error(function (error) {
            alert("We got error " + error.exceptionMessage);
        });

    };

});
