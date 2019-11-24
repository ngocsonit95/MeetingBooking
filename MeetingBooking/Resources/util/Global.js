//Biến toàn cục
var SessionAccount = {
  _account: null,
  SetAccount: function (value) {
    this._account = value;
  },
  GetAccount: function () {
    return this._account;
  }
};
