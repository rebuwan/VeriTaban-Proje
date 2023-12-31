import { Injectable } from '@angular/core';

declare var require: any;

@Injectable({
  providedIn: 'root',
})
export class CryptoService {
  constructor() {}

  encrypto(value: string): string {
    var CrypToTs = require('crypto-ts');
    return CrypToTs.AES.encrypt(value, 'secret key 123');
  }

  decrypto(value: string): string {
    var CrypToTs = require('crypto-ts');
    var bytes = CrypToTs.AES.decrypt(value, 'secret key 123');
    var plainText = bytes.toString(CrypToTs.enc.Utf8);

    return plainText;
  }
}
