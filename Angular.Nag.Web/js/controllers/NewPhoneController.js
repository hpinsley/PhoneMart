'use strict';

nagApp.controller('NewPhoneController', function NewPhoneController($scope, phoneData, $http, $location) {

    $scope.plans = phoneData.getPlans();
    $scope.manufacturers = phoneData.getManufacturers();
    
    $scope.addPhone = function(plans) {

        var planIds = [];
        for (var i = 0; i < plans.length; ++i) {
            if (plans[i].chosen) {
                planIds.push(plans[i].planId);
            }
        }
        //alert(planIds);
       
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
        .success(function (data) {
            $location.path("/phones");
        })
        .error(function (error) {
            alert("We got error " + error.exceptionMessage);
        });

    };
});
