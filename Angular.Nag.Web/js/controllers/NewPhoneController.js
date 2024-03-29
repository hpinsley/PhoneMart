﻿'use strict';

nagApp.controller('NewPhoneController', function NewPhoneController($scope, phoneData, $http, $location) {

    $scope.plans = phoneData.getPlans();
    $scope.apps = phoneData.getApps();
    $scope.manufacturers = phoneData.getManufacturers();

    $scope.cancel = function() {
        $location.path("/phones");
    };
    
    $scope.addPhone = function(plans, apps) {

        var chosenPlans = _.filter(plans, function (p) { return p.chosen; });
        var planIds = _.map(chosenPlans, function (p) { return p.planId; });
        var chosenApps = _.filter(apps, function (a) { return a.chosen; });
        var appIds = _.map(chosenApps, function (a) { return a.appId; });

        $http({
                method: "POST",
                url: nagApp.getServicesRoot() + "/api/phones",
                data: {
                    manufacturerId: $scope.manufacturerId,
                    model: $scope.model,
                    description: $scope.description,
                    price: $scope.price,
                    imageFile: "phone03.png",
                    planIds: planIds,
                    appIds: appIds
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
