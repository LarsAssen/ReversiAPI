"use strict";

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }

function _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }

Game.Reversi = function () {
  console.log('hallo, vanuit module Reversi');
  var configMap = {};

  var privateInit = function privateInit() {
    console.log('private');
  };

  return {
    init: privateInit
  };
}();

var FeedbackWidget = /*#__PURE__*/function () {
  function FeedbackWidget(elementId) {
    _classCallCheck(this, FeedbackWidget);

    this._elementId = elementId;
    this.feedback_widget_history = [];
  }

  _createClass(FeedbackWidget, [{
    key: "elementId",
    get: function get() {
      //getter, set keyword voor setter methode
      return this._elementId;
    }
  }, {
    key: "show",
    value: function show(message, type) {
      //code
      var x = document.getElementById(this._elementId);

      if (x.style.display === "none") {
        x.style.display = "block";

        if (type == "success") {
          $(x).addClass('alert-success');
        }

        if (type == "danger") {
          $(x).addClass('alert-danger');
        }

        $(x).html("<p>" + message + "</p>");
        var item = {
          type: type,
          message: message
        };
        this.log(item);
      }
    }
  }, {
    key: "hide",
    value: function hide() {
      var x = document.getElementById(this._elementId);
      x.style.display = "none";
    }
  }, {
    key: "log",
    value: function log(message) {
      this.feedback_widget_history.push(message);

      if (this.feedback_widget_history.length > 10) {
        this.removelog();
      }

      localStorage.setItem('feedback_widget_history', JSON.stringify(this.feedback_widget_history));
    }
  }, {
    key: "removelog",
    value: function removelog() {
      this.feedback_widget_history.shift();
    }
  }, {
    key: "clearStorage",
    value: function clearStorage() {
      localStorage.clear();
    }
  }, {
    key: "history",
    value: function history() {
      var item = JSON.parse(localStorage.getItem('feedback_widget_history'));
      console.log(item);

      for (var i = 0; i < item.length; i++) {
        console.log("<type |" + item[i].type + "|> - <" + item[i].message + ">");
      }
    }
  }]);

  return FeedbackWidget;
}();

var apiUrl = 'test/url';

var Game = function (url) {
  //Level 2 opdracht 1
  console.log('hallo, vanuit een module'); //Level 2 opdracht 2

  var privateInit = function privateInit() {
    console.log(configMap.api);
  };

  var configMap = {
    api: url
  };
  return {
    init: privateInit
  };
}(apiUrl);

Game.Reversi = function () {
  console.log('hallo, vanuit module Reversi');
  var configMap = {};

  var privateInit = function privateInit() {
    console.log('private');
  };

  return {
    init: privateInit
  };
}();