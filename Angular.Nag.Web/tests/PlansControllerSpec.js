'use strict';

describe("PlansController", function () {

    var $controllerConstructor;
    var scope;
    var mockPhoneData;
    var location;

    beforeEach(module('nagApp'));

    beforeEach(inject(function ($controller, $rootScope, $location) {
        $controllerConstructor = $controller;
        scope = $rootScope.$new();
        location = $location;
        mockPhoneData = sinon.stub(
            { getPlans: function () {}}
        );
    }));

    it("plansController should return obtain phone plans and set it on the scope", function() {

        var mockPlans = {dummy: 1};
        mockPhoneData.getPlans.returns(mockPlans);

        var ctrl = $controllerConstructor('PlansController',
            { $scope: scope, $location: location, phoneData: mockPhoneData });

        expect(scope.plans).toBe(mockPlans);
    });

});