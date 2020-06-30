import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
  })
export class JsonMapper 
{
    splitContent: string[][];

    public MapToJsonObject(content: string)
    {
        this.splitContent = content.split('\n').map(function (el) { return el.split(': ').join('\n').split(/\r?\n/g); });

        let counter = 0;
        let jsonoOjects = {}
        let jsonObject = {}
        for (let i = 0; i < this.splitContent.length; i++) {
            if (this.splitContent[i].length > 1) {
                jsonObject[this.splitContent[i][0]] = this.splitContent[i][1]
                jsonoOjects[counter] = jsonObject;
            }
            else
            {
                counter++;
            }
        }
        return jsonoOjects;
    }
}
