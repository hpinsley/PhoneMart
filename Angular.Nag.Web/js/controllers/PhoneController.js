'use strict';

nagApp.controller('PhoneController',
    function PhoneController($scope, phoneData) {

        $scope.name = "Howard";
        var promise = phoneData.getPhones();
        promise.then(function (phones) {
            $scope.phones = phones;
        });

        $scope.morePhones = function () {
            var numPhones = $scope.phones.length + 1;
            $scope.phones.push({ model: "Phone " + numPhones, price: 10.00 * numPhones });
        };

        $scope.lessPhones = function() {
            $scope.deletedPhone = $scope.phones.pop();
        };

        $scope.updateDescriptions = function() {
            $.each($scope.phones, function(i, phone) {
                phone.description = "Phone " + i;
                if (phone.price < 100) {
                    phone.description += "\n\nThis phone is under $100.00";
                }
            });
        };

        $scope.displayPhone = function(phone) {
            alert("Model: " + phone.model + "\n\n" + phone.description);
        };

    });
