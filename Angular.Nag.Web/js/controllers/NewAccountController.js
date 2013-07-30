'use strict';

nagApp.controller('NewAccountController', function NewAccountController($scope, $http, $location) {

    $scope.addAccount = function () {
        $http({
            method: "POST",
            url: nagApp.getServicesRoot() + "/api/accounts",
            data: {
                fullName: $scope.fullName,
                contactPhoneNumber: $scope.contactPhoneNumber,
                emailAddress: $scope.emailAddress
            }
        })
        .success(function (accountId) {
            $location.path("/accounts/" + accountId);
        })
        .error(function (error) {
            alert("We got error " + error.exceptionMessage);
        });

    };

});
