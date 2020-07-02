export class WeekNumberService{
    constructor(){}

    getWeek (value: Date){
        var date = new Date(value.getTime());
        date.setHours(0, 0, 0, 0);
        // Thursday in current week decides the year.
        date.setDate(date.getDate() + 3 - (date.getDay() + 6) % 7);
        // January 4 is always in week 1.
        var week1 = new Date(date.getFullYear(), 0, 4);
        // Adjust to Thursday in week 1 and count number of weeks from date to week1.
        return 1 + Math.round(((date.getTime() - week1.getTime()) / 86400000 - 3 + (week1.getDay() + 6) % 7) / 7);
    };

    getDateRangeOfWeek(weekNo, year) : Date[]{
        var d1, numOfdaysPastSinceLastMonday, rangeIsFrom, rangeIsTo;
        d1 = new Date('' + year + '');
        numOfdaysPastSinceLastMonday = d1.getDay() - 1;
        d1.setDate(d1.getDate() - numOfdaysPastSinceLastMonday);
        d1.setDate(d1.getDate() + (7 * (weekNo - this.getWeek(d1))));
        rangeIsFrom = (d1.getMonth() + 1) + "-" + d1.getDate() + "-" + d1.getFullYear();
        d1.setDate(d1.getDate() + 6);
        rangeIsTo = (d1.getMonth() + 1) + "-" + d1.getDate() + "-" + d1.getFullYear() ;
        return [rangeIsFrom, rangeIsTo];
    };
}

export function getCurrentYear(){
    let weekNumberService = new WeekNumberService();
    let date: Date = new Date();
    let currentWeekNumber = weekNumberService.getWeek(date);
    let currentYear = date.getFullYear();
    return '' + currentYear + currentWeekNumber
}
