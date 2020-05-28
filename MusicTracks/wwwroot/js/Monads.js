export default class Monads {

    functor(a) {
        return a.Value + 1;
    };

    

    monadUsage() {



        console.log([1, 2, 3, 4].map(i => i**2));



        const numberToString = num => num.toString();

        const array = [1, 2, 3];
        console.log(array.map(numberToString));
        //=> ["1", "2", "3"]



        function f1(x) {
            return [x + 1, x.toString() + "+1"];
        };

        function f2(x) {
            return [x + 2, x.toString() + "+2"];
        };

        function f3(x) {
            return [x + 3, x.toString() + "+3"];
        };

        function unit(x) {
            return [x, "Log"];
        };

        function bind(t, f) {
            let result = f(t[0]);
            return [result[0], t[1] + result[1] + ";"];
        };

        let log = "Log:";
        let x = 0;

        let [res, logIncr] = f1(x);
        log += logIncr + ";";

        [res, logIncr] = f2(res);
        log += logIncr + ";";

        [res, logIncr] = f3(res);
        log += logIncr + ";";

        console.log(res, log);

        console.log(bind(bind(bind(unit(x), f1), f2), f3));


        

        const getUserById = id => id === 3 ?
            Promise.resolve({ name: 'Kurt', role: 'Author' }) :
            undefined
            ;

        const hasPermission = ({ role }) => (
            Promise.resolve(role === 'Author')
        );

        const unitInit = () => (
            Promise.resolve(3)
        );

        function bind(f, g) {
            return g().then(f);
        };

        function pipeline(e, ...functors) {
            functors.forEach(function(f) {
                e = bind(f, e)
            })
            return e;
        }

        console.log(pipeline(unitInit, getUserById, hasPermission));
    };
}