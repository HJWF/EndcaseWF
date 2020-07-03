import { AppPage } from './app.po';
import { browser, logging, element } from 'protractor';

describe('workspace-project App', () => {
  let page: AppPage;

  beforeEach(() => {
    page = new AppPage();
  });

  it('should display error message when no file is selected', async () => {
    page.navigateToAdd();
    await page.getUploadButtonClick()
    let message = await page.getErrorMessageParagraphText();
    expect(message).toEqual('Geen bestand geselecteerd');
    expect(browser.getCurrentUrl()).toEqual('http://localhost:4200/add');
  });

  afterEach(async () => {
    // Assert that there are no errors emitted from the browser
    const logs = await browser.manage().logs().get(logging.Type.BROWSER);
    expect(logs).not.toContain(jasmine.objectContaining({
      level: logging.Level.SEVERE,
    } as logging.Entry));
  });
});
