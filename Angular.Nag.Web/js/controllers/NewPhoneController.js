'use strict';

nagApp.controller('NewPhoneController', function NewPhoneController($scope, phoneData, $http, $location) {
    $scope.addPhone = function() {
        alert($scope.model);
        $http({
                method: "POST",
                url: "http://localhost/Angular.Nag.Services/api/phones",
                data: {
                        model: $scope.model,
                        description: $scope.description,
                        price: $scope.price
                }
            })
        .success(function (data) {
            $location.path("/phones");
        })
        .error(function (error) {
            alert(error);
        });

    };
});
