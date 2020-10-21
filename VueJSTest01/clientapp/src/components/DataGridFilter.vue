<template>

    <div>

        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <!-- Search box -->
            <div class="container">

                <div class="main">

                    <!-- Actual search box -->
                    <div class="form-group has-feedback has-search">
                        <span class="form-control-icon-search">
                            <b-icon icon="search" aria-hidden="true"></b-icon>
                        </span>                        
                        <input id="inputSearch" type="search" class="form-control" placeholder="Search" v-model="filter">
                        <!--<span class="form-control-icon-remove" onclick="alert('ok');">
                            <b-icon icon="x" aria-hidden="true"></b-icon>
                        </span>-->
                    </div>

                    <!-- Actual advanced search box -->
                    <div id="advancedSearchMatches" role="form">
                    </div>
                </div>
            </div>

        </nav>

        <!-- Datatable -->
        <div class="container">
            <h2>Data Table</h2>
            <p>The filtered table:</p>
            <table class="table table-bordered">
                <thead>
                    <tr>
                        <th>Department</th>
                        <th>Employees</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(row, index) in filteredRows" :key="`employee-${index}`">
                        <td v-html="highlightMatches(row.department)"></td>
                        <td v-html="highlightMatches([...row.employees].sort().join(', '))"></td>
                    </tr>
                </tbody>
            </table>
        </div>

    </div>

</template>

<script>
    export default {
        name: 'DataGridFilter',
        data: function () {
            return {
                filter: '',
                rows: [
                    { department: 'Accounting', employees: ['Bradley', 'Jones', 'Alvarado'] },
                    { department: 'Human Resources', employees: ['Juarez', 'Banks', 'Smith'] },
                    { department: 'Production', employees: ['Sweeney', 'Bartlett', 'Singh'] },
                    { department: 'Research and Development', employees: ['Lambert', 'Williamson', 'Smith'] },
                    { department: 'Sales and Marketing', employees: ['Prince', 'Townsend', 'Jones'] }
                ]
            }
        },
        methods: {
            highlightMatches: function (text) {

                const matchExists = text.toLowerCase().includes(this.filter.toLowerCase());
                if (!matchExists) return text;

                const re = new RegExp(this.filter, 'ig');
                return text.replace(re, matchedText => `<strong>${matchedText}</strong>`);

            }
        },
        computed: {
            filteredRows: function () {

                return this.rows.filter(row => {

                    const employees = row.employees.toString().toLowerCase();
                    const department = row.department.toLowerCase();
                    const searchTerm = this.filter.toLowerCase();

                    return department.includes(searchTerm) ||
                        employees.includes(searchTerm);

                });

            }
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    h3 {
        margin: 40px 0 0;
    }

    ul {
        list-style-type: none;
        padding: 0;
    }

    li {
        display: inline-block;
        margin: 0 10px;
    }

    a {
        color: #42b983;
    }

    .has-search{
        display:block;
        position:relative;
    }

    /* Styles for wrapping the search box */
    .main {
        width: 50%;
        margin: 50px auto;
    }

    /* Bootstrap 4 text input with search icon */

    .form-control-icon-search {
        position: absolute;
        top: 0;
        right: 0;
        z-index: 2;
        display: block;
        width: 34px;
        height: 34px;
        line-height: 34px;
        text-align: center;
        pointer-events: none;
        right: initial;
        left: 0;
        color: #000;
    }

    .form-control-icon-remove {
        position: absolute;
        top: 0;
        right: 0;
        z-index: 3;
        display: block;
        width: 34px;
        height: 34px;
        line-height: 34px;
        text-align: center;
        cursor: pointer;
        right: 0;
        left: initial;
        color: #000;
    }

    .has-search .form-control {
        padding-right: 12px;
        padding-left: 34px;
    }

    .has-search .form-control-feedback {
        right: initial;
        left: 0;
        color: #ccc;
    }
</style>
