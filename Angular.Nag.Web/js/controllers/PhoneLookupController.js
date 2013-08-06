'use strict';

nagApp.controller('PhoneLookupController', function PhoneLookupController($scope, $routeParams, phoneData, $http, $location) {

    $scope.phoneId = $routeParams.phoneId;
    $scope.manufacturers = phoneData.getManufacturers();
    $scope.plans = phoneData.getPlans();
    $scope.phone = phoneData.getPhone($routeParams.phoneId);

    $scope.phone.then(function (phone) {
        $scope.manufacturerId = phone.manufacturer.manufacturerId;
        $scope.model = phone.model;
        $scope.description = phone.description;
        $scope.price = phone.price;

        _.each(phone.plans, function (phonePlan) {
            
        });
    });

    $scope.cancel = function() {
        $location.path("/phones");
    };
    
    $scope.updatePhone = function(plans) {

        var chosenPlans = _.filter(plans, function(p) { return p.chosen; });
        var planIds = _.map(chosenPlans, function (p) { return p.planId; });
        
        $http({
                method: "PUT",
                url: nagApp.getServicesRoot() + "/api/phones",
                data: {
                    manufacturerId: $scope.manufacturerId,
                    model: $scope.model,
                    description: $scope.description,
                    price: $scope.price,
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
