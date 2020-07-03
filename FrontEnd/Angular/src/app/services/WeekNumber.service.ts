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
}

export function getCurrentYearWeek(){
    let weekNumberService = new WeekNumberService();
    let date: Date = new Date();
    let currentWeekNumber = weekNumberService.getWeek(date);
    let currentYear = date.getFullYear();
    return '' + currentYear + currentWeekNumber
}

export function weeksInYear(year) {
    let weekNumberService = new WeekNumberService();
    let month = 11,
      day = 31,
      week;
  
    // Find week that 31 Dec is in. If is first week, reduce date until
    // get previous week.
    do {
      let d = new Date(year, month, day--);
      week = weekNumberService.getWeek(d)[1];
    } while (week == 1);
  
    return week;
  }
