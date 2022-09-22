<template>
    <div class="home">
        <h1>WeekDays</h1>
        <ul id="weekdays">
            <li v-for="item in items" :key="item.day">
                {{ item.day }} - {{item.date | formatDate}}
            </li>
        </ul>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                items: []
            }
        },
        async mounted() {
            await this.loadItems()
        },
        methods: {
            async loadItems() {
                const res = await fetch('http://localhost:52211/api/weekdays');
                const test = await res.json();
                this.items = test.weekdays;
            }
        }
    }
</script>

<style scoped>
</style>
