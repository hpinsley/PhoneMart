'use strict';

nagApp.controller('NewPhoneController', function NewPhoneController($scope, phoneData, $http, $location) {

    $scope.plans = phoneData.getPlans();
    $scope.manufacturers = phoneData.getManufacturers();
    
    $scope.addPhone = function(plans) {

        var chosenPlans = _.filter(plans, function(p) { return p.chosen; });
        var planIds = _.map(chosenPlans, function (p) { return p.planId; });
        
        $http({
                method: "POST",
                url: nagApp.getServicesRoot() + "/api/phones",
                data: {
                    manufacturerId: $scope.manufacturerId,
                    model: $scope.model,
                    description: $scope.description,
                    price: $scope.price,
                    imageFile: "phone03.png",
                    planIds: planIds
                }
            })
        .success(function () {
            $location.path("/phones");
        })
        .error(function (error) {
            alert("We got error " + error.exceptionMessage);
        });

    };
});
