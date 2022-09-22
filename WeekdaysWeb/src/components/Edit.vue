<template>
    <div class="home">
        <h1>WeekDays</h1>
        <div>
            <div>
                <date-picker type="datetime" v-model="firstDate" required></date-picker>
                <ul id="weekdays">
                    <li v-for="item in firstItems" :key="item.day">
                        {{ item.day }} - {{item.date | formatDate}}
                    </li>
                </ul>
            </div>
            <div>
                <date-picker type="datetime" v-model="secondDate" required></date-picker>
                <ul id="weekdays">
                    <li v-for="item in secondItems" :key="item.day">
                        {{ item.day }} - {{item.date | formatDate}}
                    </li>
                </ul>
            </div>
            <div>
                <date-picker type="datetime" v-model="thirdDate" required></date-picker>
                <ul id="weekdays">
                    <li v-for="item in thirdItems" :key="item.day">
                        {{ item.day }} - {{item.date | formatDate}}
                    </li>
                </ul>
            </div>
            <div>
                <date-picker type="datetime" v-model="fourthDate" required></date-picker>
                <ul id="weekdays">
                    <li v-for="item in fourthItems" :key="item.day">
                        {{ item.day }} - {{item.date | formatDate}}
                    </li>
                </ul>
            </div>
            <div>
                <date-picker type="datetime" v-model="fifthDate" required></date-picker>
                <ul id="weekdays">
                    <li v-for="item in fifthItems" :key="item.day">
                        {{ item.day }} - {{item.date | formatDate}}
                    </li>
                </ul>
            </div>
            <div>
                <date-picker type="datetime" v-model="sixthDate" required></date-picker>
                <ul id="weekdays">
                    <li v-for="item in sixthItems" :key="item.day">
                        {{ item.day }} - {{item.date | formatDate}}
                    </li>
                </ul>
            </div>
            <div>
                <date-picker type="datetime" v-model="seventhDate" required></date-picker>
                <ul id="weekdays">
                    <li v-for="item in seventhItems" :key="item.day">
                        {{ item.day }} - {{item.date | formatDate}}
                    </li>
                </ul>
            </div>
            <button @click="onClickSave"> Save </button>
            <button @click="reloadPage"> Cancel </button>
        </div>
    <ul id="weekdays">
        <li v-for="item in items" :key="item.day">
            {{ item.day }} - {{item.date}}
        </li>
    </ul>
    </div>
</template>

<script>
    import VueDatetimeJs from 'vue-datetime-js'
    import axios from 'axios'
    export default {        
        data() {
            return {
                items: [],
                firstItems: [],
                secondItems: [],
                thirdItems: [],
                fourthItems: [],
                fifthItems: [],
                sixthItems: [],
                seventhItems: []
            }
        },
        components: {
            datePicker: VueDatetimeJs
        },
        async mounted() {
            await this.loadItems()
        },
        methods: {
            async loadItems(weekdays) {
                const res = weekdays === null ? await fetch('http://localhost:52211/api/weekdays') : weekdays;
                if (res) {
                    const test = await res.json();
                    this.items = test.weekdays;
                }
            },
            async onClickSave() {
                var request = [new Date(this.firstDate).toISOString(), new Date(this.secondDate).toISOString(), new Date(this.thirdDate).toISOString(), new Date(this.fourthDate).toISOString(), new Date(this.fifthDate).toISOString(), new Date(this.sixthDate).toISOString(), new Date(this.seventhDate).toISOString()];
                const response = await axios.post("http://localhost:52211/api/weekdays", request);
                if (response) {
                    const data = await response;
                    this.firstItems = data.data[0].weekdays;
                    this.secondItems = data.data[1].weekdays;
                    this.thirdItems = data.data[2].weekdays;
                    this.fourthItems = data.data[3].weekdays;
                    this.fifthItems = data.data[4].weekdays;
                    this.sixthItems = data.data[5].weekdays;
                    this.seventhItems = data.data[6].weekdays;
                }
            },
            reloadPage() {
                window.location.reload();
            }
        }
    }
</script>

<style scoped>
</style>
