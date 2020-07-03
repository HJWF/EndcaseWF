import { browser, by, element } from 'protractor';

export class AppPage {
  navigateTo(): Promise<unknown> {
    return browser.get(browser.baseUrl) as Promise<unknown>;
  }

  navigateToAdd(): Promise<unknown> {
    return browser.get(browser.baseUrl + "/add") as Promise<unknown>;
  }

  getUploadButtonClick(){
    return element(by.id('uploadBtn')).click()
  }

  getErrorMessageParagraphText(){
    return element(by.id("errorMessage")).getText()
  }  
}
